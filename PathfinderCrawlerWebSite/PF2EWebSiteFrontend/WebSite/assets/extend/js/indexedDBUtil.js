//初始化
async function indexedDBUtilInitinalize()
{    
    checkIndexedDB().then(function (result) {
        if (result.versionChanged || result.empty) {
            //需要更新
            console.log('working');
            fetchDataAndStoreInIndexedDB();
        }
    })
    .catch(function (error) {
            console.error("Error checking IndexedDB:", error);
    });;
}

//設定檔
async function getFunctionProperties() {
    const fileVersion = await getVersionFile();
    return {
        fileVersion: fileVersion,
        dbName: 'pathfinderShareNote-database',
        storeName: 'magicStore'
    };
}


async function getVersionFile() {
    return new Promise(function (resolve, reject) {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', 'assets/extend/avrofile/Version.avro', true);
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

async function checkIndexedDB() {
    var config = await getFunctionProperties();

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

            if (dbCurrentVersion !== config.fileVersion ||
                dbCurrentVersion === 1) {
                // 版本異動，需要重抓資料
                resolve({ versionChanged: true });
            } else {
                // 版本沒變化，檢查是否空
                var transaction = db.transaction([config.storeName], 'readonly');
                var objectStore = transaction.objectStore(config.storeName);
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

async function fetchDataAndStoreInIndexedDB() {
    var config = await getFunctionProperties();
    return new Promise(function (resolve, reject) {

        var request = indexedDB.open(config.dbName, config.fileVersion);

        // 1. 無法開啟返回錯誤
        request.onerror = function (event) {
            reject("Error opening fetchDataAndStoreInIndexedDB(): " + event.target.errorCode);
        };

        request.onupgradeneeded = function (event) {
            var db = event.target.result;

            if (db.objectStoreNames.contains(config.storeName)) {
                db.deleteObjectStore(config.storeName);
            }

            // 更新數據庫結構
            var objectStore = db.createObjectStore(config.storeName, { keyPath: 'id' });
            objectStore.createIndex('magicName', 'name', { unique: false });
            objectStore.createIndex('magicType', 'type', { unique: false });
            objectStore.createIndex('magicChracter', 'chracter', { unique: false });
            objectStore.createIndex('magicAction', 'action', { unique: false });
        };

        // 2. 成功開啟進行檢查
        request.onsuccess = function (event) {
            var db = event.target.result;

            var transaction = db.transaction([config.storeName], 'readwrite');
            var objectStore = transaction.objectStore(config.storeName);
    
            // 删除之前存储的数据（如果需要）
            var clearRequest = objectStore.clear();
            clearRequest.onsuccess = function() {
                var data = { id: 3, name: 'John', type: 'fire', chracter: 'focus', action: '2' };
                objectStore.add(data);

                // 事务完成后关闭数据库
                transaction.oncomplete = function() {
                    db.close();
                    console.log('Data stored in IndexedDB');
                };
            };       
        };
    });
}
