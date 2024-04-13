<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Http\Controllers\TomegTulajdonsagokResponseController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class TomegTulajdonsagokController extends TomegTulajdonsagokResponseController
{
    public function getTomegTulajdonsagok(){
        return DB::select("call get_tomeg_tulajdonsagok_procedure();");
    }

    public function addTomegTulajdonsagok(Request $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("call add_tomeg_tulajdonsagok_procedure('".$body->token."','".$body->mertek_egysege."');");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($body, "Jogosultság megtagadva");
        }else {  
            return $this->sendResponse($DBresponse, "Tömeg tulajdonság sikeresen hozzá adva");
        }
    }
}
