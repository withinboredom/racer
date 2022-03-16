<?php

ini_set('memory_limit', '5G');

function generateFile()
{
    $file = '';
    $small_file = 4000000;
    $big_file = 4000000000;
    for ($i = 0; $i < $small_file; $i++) {
        $file .= random_int(0, 1);
    }
    file_put_contents('/file/file.bin', $file);
}

function test()
{
    $file = fopen("/file/file.bin", 'r');
    $counter = 0;
    $timer = microtime(true);
    while ( ! feof($file)) {
        $buffer = fgets($file, 4096);
        $counter += substr_count($buffer, '1');
    }
    $timer = microtime(true) - $timer;
    fclose($file);
    printf("counted %s 1s in %s milliseconds\n", number_format($counter), number_format($timer * 1000, 4));
}

function testBig()
{
    $timer = microtime(true);
    $file = file_get_contents("/file/file.bin");
    $counter = substr_count($file, '1', 0);
    $timer = microtime(true) - $timer;
    printf("counted %s 1s in %s milliseconds\n", number_format($counter), number_format($timer * 1000, 4));
}

//for ($i = 0; $i < 10; $i++) {
test();
//}

//var_dump(opcache_get_status());
