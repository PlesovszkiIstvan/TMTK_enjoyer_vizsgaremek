<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Str;
//use Illuminate\Support\Facades\Hash;
use App\Http\Controllers\FelhasznalokResponseController;
use Nette\Utils\Random;
use libcurl;


class FelhasznaloController extends FelhasznalokResponseController
{

    public function registerUser(Request $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("call check_if_felhasznalo_exist_procedure('".$body->felhasznalo_nev."', '".$body->email."');");
        if ($DBresponse[0]->result == 0) {
            $DBresponse = DB::select("CALL add_felhasznalo_procedure('".$body->felhasznalo_nev."','".$body->vezetek_nev."','".$body->kereszt_nev."','".$body->email."','".$this->hashPass($body->password)."','".$this->genEmailCode()."');");
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

    public function logIn(Request $req){
        $body = json_decode($req->getContent());        
        $DBresponse = DB::select("call logIn_felhasznalo_procedure('".$this->hashPass($body->password)."', '".$body->email."','".$this->genToken()."');");
        return $this->sendResponse($DBresponse, "A felhasználo sikeresen bejelentkezet!");
    }

    public function logOut(Request $req){
        $body = json_decode($req->getContent());
        $token = $body->token;
        $DBresponse = DB::select("call logout_procedure('".$token."')");
        return $this->sendResponse($DBresponse, "A felhasználo sikeresen kijelentkezet!");
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