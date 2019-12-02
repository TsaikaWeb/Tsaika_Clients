<?php
$nimed = simplexml_load_file("inimene.xml");
$form = "Mees";
if(isset($_GET['x'])){
    switch ($_GET['x']) {
        case 'mehed':
            $form = "Man";
            break;
        case 'naised':
            $form = "Woman";
    }
}

echo $nimed -> nimi[0] -> attributes() ->id;
function searchComputersByName($query){
    global $nimed;
    $result = array();
    foreach ($nimed -> nimi as $nimi1){
        if (substr(strtolower($nimi1 -> emakeelne), 0, strlen($query))== strtolower($query))
            array_push($result, $nimi1);
    }
    return $result;

}
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


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <title>XML Reading</title>
    <meta charset="utf-8">
</head>
<body>
<h1 class="text-center">Table of clients</h1>
<div class="container">
    <div class="row justify-content-md-center">
<table border="1" class="table table-dark table-hover">
    <tr>
        <th width="12%">Gender</th>
        <th width="12%">Name</th>
        <th width="12%">Name in different language</th>


    </tr>
    </div>
</div>
    <?php
    foreach($nimed -> nimi as $nimi1){
        echo "<tr>";
        echo "<td>".($nimi1 -> sugu)."</td>";
        echo "<td>".($nimi1 -> emakeelne)."</td>";
        echo "<td>".($nimi1 -> vorkkeelne)."</td>";
        echo "<tr>";
        //echo $arvuti -> name;
    }
    ?>
</table>
<div class="container text-center">
    <h2>First Function</h2>
</div>
<div class="container text-center bg-secondary text-white">

<h3>Last name added in table</h3>
<?php echo $nimed -> nimi[0] -> emakeelne; ?>

</div>
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
</div>
</body>
</html>
