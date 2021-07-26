# Side-project-BDOTradeData
A side project using dotnet core 3.1 and angular 12 as the webapp, and a golang client as a data crawler

You can go to https://bdo.onzero.dev to get the demo

1. The index page show the sold rank of yesterday
2. The `/search` page is a searching function to get the item price, volume, number of in stock and total sold
    - you can type `肉丸` and click the `enter` to got the result
    - if you want to view more data, you can type `肉`
    - open the `debug tools(F12)` to view the api call respond
