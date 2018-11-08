# CoordinateUUIDConverter
[![Windows](https://img.shields.io/badge/Windows-compatible-green.svg)](https://www.microsoft.com/zh-tw/windows)
[![MacOS X](https://img.shields.io/badge/MacOS%20X-compatible-green.svg)](https://www.apple.com/ca/osx/apps/app-store/)
[![Linux](https://img.shields.io/badge/Linux-compatible-green.svg)](https://www.linux.org/)

[![build](https://img.shields.io/badge/build-success-green.svg)](https://github.com/OpenISDM/CoordinateUUIDConverter/)
[![release](https://img.shields.io/badge/release-v1.0.0.0-blue.svg)](https://github.com/OpenISDM/CoordinateUUIDConverter/releases/tag/1.0.0.0)

介紹~~~

## 使用方法
**座標轉UUID**

dotnet CoordinateUUIDConverter.dll -ToUUID 緯度,經度,樓層
```
dotnet CoordinateUUIDConverter.dll -ToUUID 25.041195,121.614666,2
```
輸出格式: (緯度,經度,樓層): UUID
輸出結果: 
```
(25.04119,121.6147,2): 00000040-0000-5e54-c841-0000b63af342
```
or

dotnet CoordinateUUIDConverter.dll -ToUUID 緯度,經度
```
dotnet CoordinateUUIDConverter.dll -ToUUID 25.041195,121.614666
```
輸出格式: (緯度,經度,樓層): UUID
輸出結果: 
```
(25.04119,121.6147,1): 0000803f-0000-5e54-c841-0000b63af342
```

在沒有設定樓層的情況下，預設樓層為1樓

**UUID轉座標**

dotnet CoordinateUUIDConverter.dll -ToCoordinate UUID
```
dotnet CoordinateUUIDConverter.dll -ToCoordinate 00000040-0000-5e54-c841-0000b63af342
```
輸出格式: UUID: UUID, (緯度,經度,樓層)
輸出結果:
```
UUID: 00000040-0000-5e54-c841-0000b63af342, (25.04119,121.6147,2)
```

**批量轉換**
1.批量座標轉UUID
dotnet CoordinateUUIDConverter.dll -ToUUID 緯度,經度,樓層 緯度,經度,樓層 緯度,經度,樓層 ...
```
dotnet CoordinateUUIDConverter.dll -ToUUID 25.041195,121.614666,1 25.041396,121.615091,2 25.041968,121.615546,3
```
輸出結果:
```
(25.04119,121.6147,1): 0000803f-0000-5e54-c841-0000b63af342
(25.0414,121.6151,2): 00000040-0000-c754-c841-0000ed3af342
(25.04197,121.6155,3): 00004040-0000-f355-c841-0000293bf342
```

2.批量UUID轉座標
dotnet CoordinateUUIDConverter.dll -ToCoordinate UUID UUID UUID ...
```
dotnet CoordinateUUIDConverter.dll -ToCoordinate 0000803f-0000-5e54-c841-0000b63af342 00000040-0000-c754-c841-0000ed3af342 00004040-0000-f355-c841-0000293bf342
```
輸出結果:
```
UUID: 0000803f-0000-5e54-c841-0000b63af342, (25.04119,121.6147,1)
UUID: 00000040-0000-c754-c841-0000ed3af342, (25.0414,121.6151,2)
UUID: 00004040-0000-f355-c841-0000293bf342, (25.04197,121.6155,3)
```

## 下載
You can find the latest releases and precompiled binaries on GitHub under [Releases](https://github.com/OpenISDM/CoordinateUUIDConverter/releases).

## 編譯
您也可以選擇自行編譯程式
```
git clone https://github.com/OpenISDM/CoordinateUUIDConverter.git
cd CoordinateUUIDConverter
dotnet build --configuration Release -o bin
```
編譯完成的檔案會存放在bin資料夾

## 環境需求
[.NET Core](https://www.microsoft.com/net) v2.1
