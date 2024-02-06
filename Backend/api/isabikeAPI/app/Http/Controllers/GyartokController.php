<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class GyartokController extends Controller
{
    public function addGyarto(Request $req){
        $body = json_decode($req->getContent());
        $name = $body->gyarto_nev;
        $tell = $body->telefonszam;
        $web = $body->webhely;
        //$response = DB::select('call add_gyartok_procedure("'.$name.'");');
        $asdasd = 'call add_gyartok_procedure("'
        .$name.'","'
        .$tell.'","'
        .$web.
        '");';
        return $asdasd;
    }

    public function getGyartok(){
        $gyartok = DB::select("call get_gyartok_procedure();");

        return $gyartok;
    }

}
