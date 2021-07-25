# 미러스 엣지 카탈리스트 .chunk <-> .xlsx

## 개요
Outsidev/MirrorsEdgeCatalyst-Translation-Tool을 포크했습니다.

기존 툴이 미러스엣지 게임 경로를 잡아주면 게임 경로에 패키지파일에 직접 접근하여 chunk를 추출한 다음 엑셀파일로 변환하여 저장하고
저장된 형식의 번역된 엑셀파일을 다시 게임 경로의 패키지에 직접 패치해주는 방식이었습니다.

Frosty Editor에서 따로 추출한 chunk파일을 상호변환하는 형식으로 바꿔보고자 만들었습니다.

## 사용방법

* chk2ex : chunk폴더에 input.chunk파일을 excel폴더에 output.xlsx로 변환.
* ex2chk : excel폴더에 input.xlsx파일을 chunk폴더에 output.chunk파일로 변환.
* exit : 프로그램 종료.

아직 제대로 동작하지 못하는 수준입니다.


# Fork README.md
# MirrorsEdgeCatalyst-Translation-Tool

## What it does? 
It exports Mirror's Edge: Catalyst language subtitles to excel file and lets you import back that edited excel file.


## Parameters
-export [Game Directory] [Language shortcode]  
example : -export "C:\Games\Mirrors Edge" de  
  
-import [Game Directory] [Language shortcode] [Excel File Location]  
example : -import "C:\Games\Mirrors Edge" de "C:\Users\User\Desktop\Translation\de.xlsl"  
  
## How it works?
Export : Program must locate "[Language shortcode].toc" file inside "[Game Directory]\Patch" for extraction.  
After that it creates excel file which contains subtitles of that language at program location.    
  
Import : After editing subtitle file, program must locate corresponding cas files inside "[Game Directory]\Patch" folder.   
Then it creates backups of those files and writes new subtitles.  

## Notes

Language shortcodes: You must use language shortcodes of toc files, which is in loc folder.  

This program mostly based on english language files. Encodings may differ in other language files. Game uses it's own byte dictionary for storing characters.   
Program not in perfect state.  

This program uses EPPlus for exporting excel file.   
