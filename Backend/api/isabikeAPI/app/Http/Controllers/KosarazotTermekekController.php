<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Controllers\KosarazotTermekekResponseController;
use App\Http\Requests\KosarazotTermekekAddChecker;
use App\Http\Requests\KosarazotTermekekDeleteChecker;
use App\Http\Requests\KosarazotTermekekUpdateChecker;

class KosarazotTermekekController extends KosarazotTermekekResponseController
{
    public function getOneKosar(Request $req){
        $body = json_decode($req->getContent());
        $token = $body->token;
        //$this->bearerToken()->hasBearer($token);
        $DBresponse = DB::select("CALL get_one_kosarazot_termek_procedure('".$token."');");
        if (empty($DBresponse)) {
            return $this->sendError($DBresponse, "üres a kosarad!");
        } else {
            if ($DBresponse[0]->result == 0) {
                return $this->sendError($DBresponse, "Hibás token! nincs ilyen felhasznalo");
            } else {
                return $this->sendResponse($DBresponse, "A kosárba rakot termékek sikeresen listázva");
            }
        }
    }

    // public function getOneKosar(Request $req){                              {--- Ez az eredeti fuction ami az elvárt titkositási szabványoknak meg felel ---}
    //     $token = $req->bearerToken();
    //     $this->bearerToken()->hasBearer($token);
    //     $DBresponse = DB::select("CALL get_one_kosarazot_termek_procedure('".$token."');");
    //     if (empty($DBresponse)) {
    //         return $this->sendError($DBresponse, "üres a kosarad!");
    //     } else {
    //         if ($DBresponse[0]->result == 0) {
    //             return $this->sendError($DBresponse, "Hibás token! nincs ilyen felhasznalo");
    //         } else {
    //             return $this->sendResponse($DBresponse, "A kosárba rakot termékek sikeresen listázva");
    //         }
    //     }
    // }

    public function addToKosar(KosarazotTermekekAddChecker $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("CALL add_kosarazot_termek_procedure('".$body->token."',".$body->termek_id.",".$body->darabszam.");");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($body, "Hibás token! nincs ilyen felhasznalo");
        }elseif ($DBresponse[0]->result == 2) {
            return $this->sendError($body, "Termék menyiség hiba!");
        }else {
            return $this->sendResponse($body, "A termék sikeresen kosárba rakva");
        }
    }

    public function updateKosar(KosarazotTermekekUpdateChecker $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("CALL update_kosarazot_termeke_darabszam_procedure('".$body->token."',".$body->termek_id.",".$body->darabszam.");");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($body, "Hibás token! nincs ilyen felhasznalo");
        }elseif ($DBresponse[0]->result == 1) {
            return $this->sendError($body, "Termék menyiség hiba!");
        }else {
            return $this->sendResponse($body, "A termék sikeresen modositva a kosárban");
        }
    }

    public function deleteKosar( $termekid, KosarazotTermekekDeleteChecker $req){
        //$token = $req->bearerToken();
        //$this->bearerToken()->hasBearer($token);
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("CALL delete_kosarazot_termekek_procedure('".$body->token."',".$termekid.");");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($body, "Hibás token! nincs ilyen felhasznalo");
        } else {
            return $this->sendResponse($body, "A termék sikeresen törölve a kosárbol");
        }
    }

    // public function deleteKosar(KosarazotTermekekDeleteChecker $req){                {--- Ez az eredeti fuction ami az elvárt titkositási szabványoknak meg felel ---}
    //     $token = $req->bearerToken();
    //     $this->bearerToken()->hasBearer($token);
    //     $body = json_decode($req->getContent());
    //     $DBresponse = DB::select("CALL delete_kosarazot_termekek_procedure('".$token."',".$body->termek_id.");");
    //     if ($DBresponse[0]->result == 0) {
    //         return $this->sendError($body, "Hibás token! nincs ilyen felhasznalo");
    //     } else {
    //         return $this->sendResponse($body, "A termék sikeresen törölve a kosárbol");
    //     }
    // }
}
