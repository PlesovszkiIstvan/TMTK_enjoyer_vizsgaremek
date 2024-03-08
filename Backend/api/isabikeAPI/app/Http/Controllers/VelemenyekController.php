<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Http\Controllers\VelemenyekResponseController;
use Illuminate\Support\Facades\DB;
use App\Http\Requests\VelemenyekAddChecker;

class VelemenyekController extends VelemenyekResponseController
{
    public function getVelemenyek(){
        return DB::select("CALL get_velemenyek_procedure();");
    }

    public function addVelemenyek(VelemenyekAddChecker $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("CALL add_velemenyek_procedure('".$body->token."',".$body->ertekeles_id.",'".$body->velemeny."');");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($DBresponse, "A vélemény hagyás elutasitva");
        } else {
            return $this->sendResponse($DBresponse, "A vélemény sikeresen hozzá adva");
        }
    }

    public function deleteVelemenyek(Request $req){
        $token = $req->bearerToken();
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("call change_velemenyek_lathato_procedure('".$token."',".$body->velemeny_id.");");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($DBresponse, "Jogosultság megtagadva");
        } else {
            return $this->sendResponse($DBresponse, "Vélemény elérhetösége sikeresen megváltoztatva");
        }
    }
}
