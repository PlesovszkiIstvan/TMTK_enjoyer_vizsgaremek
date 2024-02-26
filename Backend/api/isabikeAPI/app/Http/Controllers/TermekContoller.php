<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Controllers\TermekekResponseController;
use App\Http\Requests\TermekekAddChecker;
use App\Http\Requests\TermekekUpdateChecker;
use App\Http\Requests\TermekekDeleteChecker;

class TermekContoller extends TermekekResponseController
{
    public function getTermekek(){
        $termekek = DB::select("call get_termekek_procedure();");

        return $termekek;
    }

    public function addTermek(TermekekAddChecker $req){
        $body = json_decode($req->getContent());
        $token = $body->token;
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
        $response = DB::select('call add_termek_procedure("'
        .$token.'","'
        .$termek_kateg.'","'
        .$termek_nev.'",'
        .$gyarto_id.','
        .$raktarondb.','
        .$tomeg_tulajdonsaga_id.','
        .$tomeg_erteke.',"'
        .$szine.'","'
        .$leiras.'",'
        .$egyseg_ar.
        ');');
        if ($response[0]->result == 0) {
            return $this->sendError($body, "Jogosultsági hiba!");
        } else {
            return $this->sendResponse($response, "Termék sikeresen hozzáadva!");
        }
    }

    public function updateTermek(TermekekUpdateChecker $req){

        $body = json_decode($req->getContent());
        $token = $body->token;
        $termek_id = $body->termek_id;
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
        $response = DB::select('call update_termek_procedure("'
        .$token.'",'
        .$termek_id.',"'
        .$termek_kateg.'","'
        .$termek_nev.'",'
        .$gyarto_id.','
        .$raktarondb.','
        .$tomeg_tulajdonsaga_id.','
        .$tomeg_erteke.',"'
        .$szine.'","'
        .$leiras.'",'
        .$egyseg_ar.
        ');');
        if ($response[0]->result == 0) {
            return $this->sendError($body, "Jogosultsági hiba!");
        } else {
            return $this->sendResponse($response, "Termék sikeresen modositva!");
        }
    }

    public function deleteTermek(TermekekDeleteChecker $req){
        $token = $req->bearerToken();
        $body = json_decode($req->getContent());
        $response = DB::select("call update_termekek_elerheto_procedure('".$token."',".$body->termek_id.");");
        if ($response[0]->result == 0) {
            return $this->sendError($response, "Hibás token vagy nem létezö termék");
        } else {
            return $this->sendResponse($response, "A termék elérhetösége sikeresen modositva");
        }
        
    }
}
