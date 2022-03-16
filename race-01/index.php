<?php

// we are merely racing to 4 million iteration in a for-loop

// put into function so it will jit
function test()
{
    $counter = 0;
    
    $timer = microtime(true);
    for ($i = 0; $i < 4000000; $i++) {
        ++$counter;
    }
    $timer = microtime(true) - $timer;
    
    printf("Counted to %s in %s milliseconds\n", number_format($counter), number_format($timer * 1000, 5));
}

test();
