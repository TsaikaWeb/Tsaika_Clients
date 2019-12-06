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
## PHP функция для поиска человека по имени
```
echo $nimed -> nimi[0] -> attributes() ->id;
function searchInimesedByName($query){
    global $nimed;
    $result = array();
    foreach ($nimed -> nimi as $nimi1){
        if (substr(strtolower($nimi1 -> emakeelne), 0, strlen($query))== strtolower($query))
            array_push($result, $nimi1);
    }
    return $result;
}
```
## PHP функция для поиска человека по полу
```
function searchInimesedBySugu($query){
    global $nimed;
    $result = array();
    foreach ($nimed -> nimi as $nimi1){
        if (substr(strtolower($nimi1 -> emakeelne), 0, strlen($query))== strtolower($query))
            array_push($result, $nimi1);
    }
    return $result;
}
?>
```
## Первая фунция - вывод первого имени из таблицы
```
<div class="container text-center">
    <h2>First Function</h2>
</div>
<div class="container text-center bg-secondary text-white">

<h3>Last name added in table</h3>
<?php echo $nimed -> nimi[0] -> emakeelne; ?>

</div>
```
## Вторая функция - вывод таблицы с возможностью поиска
```
<div class="container text-center ">

    <h2>Second Function</h2>

<div class=" text-center bg-secondary text-white">

<h3>Search by name:</h3>
    <form action="?" method="post">
        <input type="text" name="search" placeholder="Name"/>
        <input type="submit" value="Leida" />
    </form>
    <table border="1" class="table table-dark table-hover">
        <tr>
            <th>Gender</th>
            <th>Name</th>
            <th>Name in different language</th>


        </tr>
        <?php
        if (!empty($_POST["search"])){
            $result = searchInimesedBySugu($_POST["search"]);
            foreach ($result as $nimi1){
                echo "<tr>";
                echo "<td>".($nimi1 -> sugu)."</td>";
                echo "<td>".($nimi1-> emakeelne)."</td>";
                echo "<td>".($nimi1-> vorkkeelne)."</td>";
                echo "<tr>";
                //echo $arvuti -> name;
            }
        }
        ?>

    </table>

</div>
</div>
```
## Третья функция - вывод таблицы, и сортировка по полу 
```
<div class="container">
    <div class="row justify-content-md-center">

        <a href="index.php?x=mehed"><h3>Display only men</h3></a>
        <hr>
        <a href="index.php?x=naised"><h3>Display only women</h3></a>



        <table class="table table-dark table-hover">
            <thead>
            <tr>
                <th scope="col">Gender</th>
                <th scope="col">Name</th>
                <th scope="col">Name in different language</th>


            </tr>
            </thead>
            <tbody>
            <?php
            foreach($nimed->nimi as $nimi2) {
                if($nimi2->sugu == $form){
                    echo '<tr>';
                    echo '<td>'.$nimi2->emakeelne.'</td>';
                    echo '<td>'.$nimi2->vorkkeelne.'</td>';
                    echo '<td>'.$nimi2->sugu.'</td>';
                    echo '</tr>';
                }
            }
            ?>
            </tbody>
        </table>
</div>
```
# Проект на ASP.NET
Создать веб страницу используя ASP NET MVC Web API. На данной веб-странице пользователи могут зарегистрироваться и авторизироваться. У пользователей должно быть 3 роли, такие как :

- Анонимный пользователь ( не зарегистрированный )
- Юзер ( зарегистрированный)
- Администратор

## Главная страница
<img src="images/index.png" width="200" height="50"/>


