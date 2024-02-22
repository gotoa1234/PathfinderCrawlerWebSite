<!-- 概念圖 -->
```mermaid
mindmap
   root(("PF2E 網站 - 查詢魔法功能"))
      root_a["網站的排版"]
         root_a_1["Html5up的版型"]                  
      root_b["網站的資料來源"]
         root_b_1["取得後端程序爬蟲後的 Avro 檔案"]            
            root_b_1_1["取得 Avro 關鍵版號，若有更新，則 IndexDB 重新載入"]
            root_b_1_2["使用 IndexedDB 存在瀏覽器端"]
         root_b_2["後端運行一個爬蟲程序"]            
            root_b_2_1["將資料寫到 Avro 檔案，並且保存在 Github 上開源"]            
            root_b_2_2["Avro 檔案，要標記版號"]            
      root_c["功能"]
         root_c_1["考慮用 Netlify 架站"]
         root_c_2["考慮用 Lunar.js 做搜尋引擎"]
         root_c_3["考慮有 PDF 匯出下載功能 "]
         root_c_4["考慮有職業引導介面"]
         root_c_5["需要有魔法分類表"]

```

<!--
https://bojne.medium.com/%E4%B8%89%E6%AD%A5%E9%A9%9F%E7%94%A8-netlify-%E8%BC%95%E9%AC%86%E6%9E%B6%E7%B6%B2%E7%AB%99-67d65ce135f6

Get-Content .\User.avsc | dotnet avro generate | Out-File .\AvroClass\User.cs

-->