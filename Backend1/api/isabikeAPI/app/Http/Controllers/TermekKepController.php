<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Http\Requests\TermekKepAddChecker;
use Illuminate\Support\Facades\DB;
use App\Http\Controllers\TermekKepResponseController;

class TermekKepController extends TermekKepResponseController
{
    public function addTermekKep(TermekKepAddChecker $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("call add_termek_kep_procedure('".$body->token."',".$body->termek_id.",'".$body->kep_helye."');");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($DBresponse, "Jogosultság megtagadva");
        } else {
            return $this->sendResponse($DBresponse, "Kép sikeresen hozzáadva");
        }
    }

    public function deleteTermekKep(Request $req){
        $token = $req->bearerToken();
        $this->bearerToken()->hasBearer($token);
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("CALL delete_termek_kep_procedure('".$token."',".$body->termek_id.");"); 
        return $DBresponse;
    }

    public function getOneTermekKepek($termekId){
        $DBresponse = DB::select("CALL get_termek_kepek_procedure(".$termekId.");");
    }
}
