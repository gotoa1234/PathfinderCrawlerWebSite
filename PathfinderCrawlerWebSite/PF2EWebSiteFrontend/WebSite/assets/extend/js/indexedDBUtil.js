async function getVersionFile() {
    return new Promise(function(resolve, reject) {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', 'assets/avrofile/Version.avro', true);
        xhr.responseType = 'arraybuffer';
        xhr.onload = function () {
            var buffer = xhr.response;
            var avroData = new Uint8Array(buffer);
    
            // 手动解析 Avro 数据
            var bytes = avroData.slice(0, 4);
            var version = Array.prototype.map.call(bytes, function(byte) {
                return ('0' + (byte & 0xFF).toString(4)).slice(-2);
            }).join('');        
            resolve(version);
        };
        xhr.send();
    });
}

async function checkIndexedDBData() {
    var version = await getVersionFile();
    var dbName = 'pathfinderShareNote-database';
    var stroeName = 'magicStore';
    var request = indexedDB.open(dbName, 1);
      
    //#region 出錯事件
    request.onerror = function(event) {
      console.error( dbName + 'Database error:', event.target.error);
    };
    //#endregion 
    
    //#region 資料庫重建事件，資料庫版本不一致時
    request.onupgradeneeded = function(event) {
        var db = event.target.result;
        // 創建物件儲存空間，並且指定路徑
        var objectStore = db.createObjectStore(stroeName, { keyPath: 'id' });
        // TODO: 讀取 .avro 建立基本資料
        // mock data
        objectStore.createIndex('data', 'data', { unique: false });
        
        var transaction = db.transaction([stroeName], 'readwrite');
        AddData(transaction);
    };
    //#endregion    

    //#region 成功事件
    request.onsuccess = function(event) {
        var db = event.target.result;
    
        // 交易事件
        var transaction = db.transaction([stroeName], 'readonly');
        transaction.onerror = function(event) {
            console.error('Transaction error:', event.target.error);
        };
    
        transaction.oncomplete = function(event) {
            console.log('Transaction completed');
        };
    
        var objectStore = transaction.objectStore(stroeName);
    
        var getRequest = objectStore.get(1);
    
        getRequest.onerror = function(event) {
          console.error('Get data error:', event.target.error);
        };
    
        getRequest.onsuccess = function(event) {
          var data = event.target.result;
    
          if (!data) {
            console.log('Data not found in IndexedDB, reloading page...');          
          } else {
            console.log('Data retrieved from IndexedDB:', data);
          }
        };
    };
    //#endregion


    //// 增加資料功能
    function AddData(transaction)
    {
        var objectStore = transaction.objectStore(stroeName);
        var data = { id: 1, name: 'John' };
        var request = objectStore.add(data);
      
        // 数据添加失败
        request.onerror = function(event) {
          console.error('Add data error:', event.target.error);
        };
      
        // 数据添加成功
        request.onsuccess = function(event) {
          console.log('Data added to IndexedDB');
        };
    }
}
