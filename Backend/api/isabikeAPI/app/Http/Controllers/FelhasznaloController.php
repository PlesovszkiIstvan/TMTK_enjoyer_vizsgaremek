<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Str;
//use Illuminate\Support\Facades\Hash;
use App\Http\Controllers\FelhasznalokResponseController;
use App\Http\Controllers\EmailController;
use App\Http\Requests\FelhasznalokRegistChecker;
use App\Http\Requests\FelhasznalokLogInChecker;

use Nette\Utils\Random;
use libcurl;


class FelhasznaloController extends FelhasznalokResponseController
{

    public function registerUser(FelhasznalokRegistChecker $req){
        $req->validated();
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("call check_if_felhasznalo_exist_procedure('".$body->felhasznalo_nev."', '".$body->email."');");
        if ($DBresponse[0]->result == 0) {
            $emailCode = $this->genEmailCode();
            ( new EmailController)->sendVisszaIgazoloMail($emailCode, $body->email);
            $DBresponse = DB::select("CALL add_felhasznalo_procedure('".$body->felhasznalo_nev."','".$body->vezetek_nev."','".$body->kereszt_nev."','".$body->email."','".$this->hashPass($body->password)."','".$emailCode."');");
            return $this->sendResponse($DBresponse,"Felhasználo sikeresen regisztrálva!");
        }else {
            return $this->sendError($body, "Ez a felhasználo már létezik!");
        }
    }

    public function verifyUser(Request $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("call verify_felhasznalo_procedure('".$body->code."');");
        return $this->sendResponse($DBresponse, "Email vissza igazolva!");
    }

    public function logIn(FelhasznalokLogInChecker $req){
        $body = json_decode($req->getContent());        
        $DBresponse = DB::select("call logIn_felhasznalo_procedure('".$this->hashPass($body->password)."', '".$body->email."','".$this->genToken()."');");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($body, "Hibás email jelszo páros, vagy már be van jelentkezve valaki a fiokba");
        } else {
            return $this->sendResponse($DBresponse[0]->token, "A felhasználo sikeresen bejelentkezet!");
        }
    }

    public function logOut(Request $req){
        $body = json_decode($req->getContent());
        $token = $body->token;
        $DBresponse = DB::select("call logout_procedure('".$token."')");
        return $this->sendResponse($DBresponse, "A felhasználo sikeresen kijelentkezet!");
    }

    public function getFelhasznalok(Request $req){
        $token = $req->bearerToken();
        $this->bearerToken()->hasBearer($token);
        $DBresponse = DB::select("call get_felhasznalok_procedure('".$token."');");
        if ($DBresponse[0]->result > 0) {
            return $this->sendResponse($DBresponse, "Felhasználok lekérve admin által");
        } else {
            return $this->sendError($DBresponse, "Jogosultság elutasitva!");
        }
    }

    public function updateFelhasznalo(Request $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("call update_felhasznalok_procedure('"
        .$body->token."',"
        .$body->felhasznalo_id.",'"
        .$body->felhasznalo_nev."','"
        .$body->vezetek_nev."','"
        .$body->kereszt_nev."','"
        .$body->vasarlo_telefonszama."','"
        .$body->email."','"
        .$body->jelszo."','"
        .$body->szalitasi_cime."',"
        .$body->jogosultsag.","
        .$body->aktiv.
        "
        );");
        if ($DBresponse[0]->result > 0) {
            return $this->sendResponse($DBresponse, "Felhasználo sikeresen modositva admin által");
        } else {
            return $this->sendError($DBresponse, "Jogosultság megtagadva vagy Hibás paraméterek");
        }
        
    }

    public function updateOneFelhasznalo(Request $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("call update_one_felhasznalo_procedure('"
        .$body->token."','"
        .$body->felhasznalo_nev."','"
        .$body->vezetek_nev."','"
        .$body->kereszt_nev."','"
        .$body->vasarlo_telefonszama."','"
        .$body->email."','"
        .$body->szalitasi_cime."');");
        if ($DBresponse[0]->result > 0) {
            return $this->sendResponse($DBresponse, "Felhasználofiok sikeresen modositva");
        } else {
            return $this->sendError($DBresponse, "Jogosultság megtagadva vagy Hibás paraméterek");
        }
    }

    public function getOneFelhasznalo(Request $req){
        $token = $req->bearerToken();
        $this->bearerToken()->hasBearer($token);
        $DBresponse = DB::select("call get_one_felhasznalo_procedure('".$token."');");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($DBresponse, "ilyen felhasználo nincs");
        } else {
            return $this->sendResponse($DBresponse, "Felhasznalo adatok sikeresen listázva");
        }
        return $token;
    }

    private function genToken(){
        return Random::generate(60, "0-9a-zA-Z");
    }

    private function hashPass($pass){
        return hash_hmac('sha256', $pass, "saláta");
    }

    private function genEmailCode():string 
    {
        return Random::generate(5, "0-9");
    }

}