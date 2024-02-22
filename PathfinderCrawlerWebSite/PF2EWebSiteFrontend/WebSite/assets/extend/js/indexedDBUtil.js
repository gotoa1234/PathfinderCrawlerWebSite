//設定檔
async function getFunctionProperties() {

    async function innerFunction() {
        this.fileVersion = await getVersionFile();
        this.dbName = 'pathfinderShareNote-database';
        this.stroeName = 'magicStore';


        async function getVersionFile() {
            return new Promise(function (resolve, reject) {
                var xhr = new XMLHttpRequest();
                xhr.open('GET', 'assets/avrofile/Version.avro', true);
                xhr.responseType = 'arraybuffer';
                xhr.onload = function () {
                    var buffer = xhr.response;
                    var avroData = new Uint8Array(buffer);

                    // 手动解析 Avro 数据
                    var bytes = avroData.slice(0, 4);
                    var version = new DataView(bytes.buffer).getInt32(0, true); // 解析整数值            
                    resolve(version);
                };
                xhr.send();
            });
        }

    }

    var obj = new innerFunction(); 
    return obj;
}



async function checkIndexedDB() {
    var config = getFunctionProperties();
    //var fileVersion = await getVersionFile();
    //var dbName = 'pathfinderShareNote-database';
    //var stroeName = 'magicStore';    

    return new Promise(function (resolve, reject) {
        var request = indexedDB.open(config.dbName);

        // 1. 無法開啟返回錯誤
        request.onerror = function (event) {
            reject("Error opening IndexedDB: " + event.target.errorCode);
        };

        // 2. 成功開啟進行檢查
        request.onsuccess = function (event) {
            var db = event.target.result;
            var dbCurrentVersion = db.version;

            if (dbCurrentVersion !== config.fileVersion) {
                // 版本異動，需要重抓資料
                resolve({ versionChanged: true });
            } else {
                // 版本沒變化，檢查是否空
                var transaction = db.transaction([config.stroeName], 'readonly');
                var objectStore = transaction.objectStore(config.stroeName);
                var countRequest = objectStore.count();

                countRequest.onsuccess = function () {
                    var count = countRequest.result;
                    if (count === 0) {
                        // 資料空，重新抓資料
                        resolve({ empty: true });
                    } else {
                        // 不異動
                        resolve({ versionChanged: false, empty: false });
                    }
                };

                countRequest.onerror = function () {
                    reject("Error counting objects in IndexedDB.");
                };
            }
        };
    });
}

async function checkIndexedDBData() {
    var config = getFunctionProperties();
    //var version = await getVersionFile();
    //var dbName = 'pathfinderShareNote-database';
    //var stroeName = 'magicStore';
    var request = indexedDB.open(config.dbName, 1);
      
    //#region 出錯事件
    request.onerror = function(event) {
      console.error( dbName + 'Database error:', event.target.error);
    };
    //#endregion 
    
    //#region 資料庫重建事件，資料庫版本不一致時
    request.onupgradeneeded = function(event) {
        var db = event.target.result;
        // 1. 檢查是否存在舊的 IndexedDB
        if (db.objectStoreNames.contains(config.stroeName)) {
            //進行刪除
            db.deleteObjectStore(config.stroeName);
        }

        // 2. 創建物件儲存空間，並且指定路徑        
        var objectStore = db.createObjectStore(config.stroeName, { keyPath: 'id' });
        // TODO: 讀取 .avro 建立基本資料表
        objectStore.createIndex('data', 'data', { unique: false });
    };
    //#endregion    

    //#region 成功事件
    request.onsuccess = function(event) {
        var db = event.target.result;

        // 交易事件
        var transaction = db.transaction([config.stroeName], 'readonly');
        transaction.onerror = function(event) {
            console.error('Transaction error:', event.target.error);
        };
    
        transaction.oncomplete = function(event) {
            console.log('Transaction completed');
        };

        AddData(db);

        var objectStore = transaction.objectStore(config.stroeName);
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
    function AddData(db)
    {
        //var transaction = db.transaction([stroeName], 'readwrite');        
        //var objectStore = transaction.objectStore(stroeName);

        //var data = { id: 2, name: 'John', type: 'fire', chracter: 'focus', action: '2' };
        //var request = objectStore.add(data);

        //// 数据添加失败
        //request.onerror = function(event) {
        //  console.error('Add data error:', event.target.error);
        //};
      
        //// 数据添加成功
        //request.onsuccess = function(event) {
        //  console.log('Data added to IndexedDB');
        //};
    }
}
