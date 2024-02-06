<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class TermekContoller extends Controller
{
    public function getTermekek(){
        $termekek = DB::select("call get_termekek_procedure();");

        return $termekek;
    }

    public function addTermek(Request $req){
        $body = json_decode($req->getContent());
        $termek_kateg = $body->termek_kateg;
        $termek_nev = $body->termek_nev;
        $gyarto_id = $body->gyarto_id;
        $raktarondb = $body->raktarondb;
        $tomeg_tulajdonsaga_id = $body->tomeg_tulajdonsaga_id;
        $tomeg_erteke = $body->tomeg_erteke;
        $szine = $body->szine;
        $leiras = $body->leiras;
        $egyseg_ar = $body->egyseg_ar;
        $elerheto = $body->elerheto;
        $response = 'call add_termek_procedure("'
        .$termek_kateg.'","'
        .$termek_nev.'",'
        .$gyarto_id.','
        .$raktarondb.','
        .$tomeg_tulajdonsaga_id.','
        .$tomeg_erteke.',"'
        .$szine.'","'
        .$leiras.'",'
        .$egyseg_ar.
        ');';
        return DB::select($response);
    }

    public function updateTermek($id, Request $req){
        $body = json_decode($req->getContent());
        $termek_kateg = $body->termek_kateg;
        $termek_nev = $body->termek_nev;
        $gyarto_id = $body->gyarto_id;
        $raktarondb = $body->raktarondb;
        $tomeg_tulajdonsaga_id = $body->tomeg_tulajdonsaga_id;
        $tomeg_erteke = $body->tomeg_erteke;
        $szine = $body->szine;
        $leiras = $body->leiras;
        $egyseg_ar = $body->egyseg_ar;
        $elerheto = $body->elerheto;
        $response = 'call update_termek_procedure('
        .$id.',"'
        .$termek_kateg.'","'
        .$termek_nev.'",'
        .$gyarto_id.','
        .$raktarondb.','
        .$tomeg_tulajdonsaga_id.','
        .$tomeg_erteke.',"'
        .$szine.'","'
        .$leiras.'",'
        .$egyseg_ar.
        ');';
        //return $response;
        return DB::select($response);
    }

    public function deleteTermek($id){
        return DB::select("call update_termekek_elerheto_procedure(".$id.");");
    }
}
