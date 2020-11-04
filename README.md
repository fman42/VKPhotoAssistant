![alt text](https://github.com/fman42/VKPhotoAssistant/blob/master/VKPhotoAssistant.png)

**If you always upload photos by any devices in albums and you want download in future to your local PC those photos from the social network vk.com then this library will help you with that proccess**

**Versions of programm are available for Windows, Linux and MacOS**

## 1.Commands
Get all available commands of programm
```
VKPhotoAssistant.exe help
```

## 1.1. VKStorage
Set a token in local storage or rewrite existed token by passed id in **index**
```
VKPhotoAssistant.exe vk set [value] --index [index]
```

Get all tokens from local storage or get specified token by id
```
VKPhotoAssistant.exe vk get --index [index]
```

Remove a token by its id
```
VKPhotoAssistant.exe vk remove [index]
```

Set a token as default in config of program
```
VKPhotoAssistant.exe vk apply [index]
```

## 1.2. Album
##### &#10071; This utility will be worked if you use VKPhotoAssistant.exe vk apply [index]

Get available user's albums from vk.com (except: saved, walls albums)
```
VKPhotoAssistant.exe album get
```

Start download photos from album by albumId.
```
VKPhotoAssistant.exe album download [albumId] --limit [limit] --offset [offset]
```
**Parameters**

**albumId** - albumId from API(to use **album get**)

**limit** - set limit for download some photos(Max: **1000**. Defaultl: **100**)

**offset** - set offset from 0 index (Default: **0**)


