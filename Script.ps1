﻿#  Script.sh


#  
#

#  Created by Артём Семёнов on 09.03.2018.

#  



$variable=9



do {
Write-Host "какой тест?"

Write-Host "1. Присваение."

Write-Host "2. Условие."

Write-Host "3. Цикл FOR."

Write-Host "4. Цикл While."

Write-Host "5. Комбинированный вариант."
Write-Host "6. Логика."
Write-Host "0. Выход."
$variable = Read-Host
switch ($variable) {

1 {.\bin\Debug\SimpleLang.exe .\Test\as\as.txt}
2 {.\bin\Debug\SimpleLang.exe .\Test\if\if.txt}
3 {.\bin\Debug\SimpleLang.exe .\Test\for\for.txt}
4 {.\bin\Debug\SimpleLang.exe .\Test\while\while.txt}
5 {.\bin\Debug\SimpleLang.exe .\Test\comby\comby.txt}
6 {.\bin\Debug\SimpleLang.exe .\Test\logic\logic.txt}
0 {Write-Host "выход"}
Default {Write-Host "ошибка"}
}

} while ($variable -ne 0)