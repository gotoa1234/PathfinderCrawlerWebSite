// Session Storage 存資料
function saveToSessionStorage(key, value) {
    sessionStorage.setItem(key, JSON.stringify(value));
}

// 從 Session Storage 取資料
function getFromSessionStorage(key) {
    const storedValue = sessionStorage.getItem(key);
    return storedValue ? JSON.parse(storedValue) : null;
}

// 從 Session Storage 刪除指定資料
function deleteFromSessionStorage(key) {
    sessionStorage.removeItem(key);    
}