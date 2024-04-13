<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Controllers\GyartokResponseController;
use App\Http\Requests\GyartokAddChecker;
use App\Http\Requests\GyartokUpdateChecker;

class GyartokController extends GyartokResponseController
{
    public function addGyarto(GyartokAddChecker $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("call add_gyartok_procedure('".$body->token."','".$body->gyarto_neve."','".$body->telefonszama."','".$body->webhely."');");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($DBresponse, "Jogosultság meg tagadva");
        } else {
            return $this->sendResponse($DBresponse, "Gyarto sikeresen hozzáadva");
        }
        
    }

    public function getGyartok(){
        $gyartok = DB::select("call get_gyartok_procedure();");

        return $gyartok;
    }

    public function updateGyarto(GyartokUpdateChecker $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("call update_gyartok_procedure('".$body->token."',".$body->gyarto_id.",'".$body->gyarto_neve."','".$body->telefonszama."','".$body->webhely."');");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($DBresponse, "Jogosultság meg tagadva");
        } else {
            return $this->sendResponse($DBresponse, "Gyarto sikeresen modositva");
        }
    }
}
