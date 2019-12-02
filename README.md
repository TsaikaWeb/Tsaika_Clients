# Документация к проекту
## [Документация по PHP проекту](https://tsaika17.thkit.ee/TsaikaPHP/index.php?x=mehed)
- Создать XML файл в который будет 2 или 3 логичиских диапазона.
- Файл должен содержать следующие поля :
  - iв
  - sugu
  - emakeelne nimi
  - võõrkeelne nimi
- Сделать вывод таблицы на HTML с использованием :
  - PHP
  - XSLT
- Придумать минимум 3 свои функции :
  - Показывать только мужское или женское имя
  - Вывод первого значения с базы данных
  - Поиск по родному имени
## XML файл
```
<?xml version="1.0" encoding="utf-8" ?>

<nimed>
  <nimi id="1">
    <sugu>Man</sugu>
    <emakeelne>Aleksandr</emakeelne>
    <vorkkeelne>Aleksander</vorkkeelne>
  </nimi>
  <nimi id="2">
    <sugu>Man</sugu>
    <emakeelne>Aleksey</emakeelne>
    <vorkkeelne>Alexey</vorkkeelne>
  </nimi>
  <nimi id="3">
    <sugu>Man</sugu>
    <emakeelne>Artem</emakeelne>
    <vorkkeelne>Artyom</vorkkeelne>
  </nimi>
  <nimi id="4">
    <sugu>Woman</sugu>
    <emakeelne>Anzhela</emakeelne>
    <vorkkeelne>Angela</vorkkeelne>
  </nimi>
  <nimi id="5">
    <sugu>Woman</sugu>
    <emakeelne>Darya</emakeelne>
    <vorkkeelne>Daria</vorkkeelne>
  </nimi>

</nimed>
```
