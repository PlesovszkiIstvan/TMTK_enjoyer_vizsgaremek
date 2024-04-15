<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use App\Http\Controllers\RendelesekResponseController;
use Illuminate\Http\Request;
use App\Http\Requests\GetRendelesekChecker;
use App\Http\Requests\AddRendelesChecker;
use Illuminate\Support\Facades\DB;
use App\Http\Controllers\EmailController;



class RendelesekController extends RendelesekResponseController
{
    public function addRendeles(AddRendelesChecker $req){
        $body = json_decode($req->getContent());
        $DBresponse = DB::select("CALL add_rendeles_procedure('".$body->token."','".$body->vasarlo_telefonszama."','".$body->szalitasi_cime."','".$body->megjegyzes."',".$body->szalito_id.",".$body->fizetes_opcio_id.",".$body->kedvezmeny_id.");");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($body, "Hibás token ilyen felhasználo nem létezik");
        } else {
            $rendelt_termekek = DB::select("CALL get_one_rendeles_termekek_procedure(".$DBresponse[0]->rendeles_id.");");
            $DBresponse["rendelt_termekek"] = $rendelt_termekek;
            $email = $DBresponse[0]->email;
            ( new EmailController)->sendRendelesMail($rendelt_termekek, $DBresponse[0]->rendeles_ideje, $DBresponse[0]->megjegyzes, $DBresponse[0]->felhasznalo_nev, $DBresponse[0]->szalitasi_cime, $DBresponse[0]->vasarlo_telefonszama, $email);
            $DBresponse["rendelt_termekek"] = $rendelt_termekek;
            return $this->sendResponse($DBresponse, "Rendelés sikeresen leadva");
        }     
    }

    public function getOneRendeles(Request $req){
        $body = json_decode($req->getContent());
        $token = $body->token;
        $DBresponse1 = DB::select("CALL get_one_rendeles_procedure('".$token."');");
        if (empty($DBresponse1)) {
            return $this->sendError($body, "Nincs még rendelésed");
        } else {
            if ($DBresponse1[0]->result == 0) {
                return $this->sendError($body, "Hibás token ilyen felhasználo nem létezik");
            } else {
                return $this->sendResponse($DBresponse1, "Felhasznalo rendelései sikeresen kilistázva");
            }
        }

    }

    // public function getOneRendelesOriginal(Request $req){                        {-------eredeti fuction megfelelö biztonsági szabványok szerint}
    //     $token = $req->bearerToken();
    //     $body = json_decode($req->getContent());
    //     $this->bearerToken()->hasBearer($token);
    //     $DBresponse1 = DB::select("CALL get_one_rendeles_procedure('".$token."');");
    //     if (empty($DBresponse1)) {
    //         return $this->sendError($body, "Nincs még rendelésed");
    //     } else {
    //         if ($DBresponse1[0]->result == 0) {
    //             return $this->sendError($body, "Hibás token ilyen felhasználo nem létezik");
    //         } else {
    //             $DBresponse2 = DB::select("CALL get_one_rendeles_termekek_procedure(".$DBresponse1[0]->rendeles_id.");");
    //             $DBresponse1["rendelt_termekek"] = $DBresponse2;
    //             return $this->sendResponse($DBresponse1, "Felhasznalo rendelései sikeresen kilistázva");
    //         }
    //     }

    // }

    public function getAllRendeles(Request $req){
        $token = $req->bearerToken();
        $body = json_decode($req->getContent());
        $this->bearerToken()->hasBearer($token);
        $DBresponse = DB::select("CALL get_all_rendeles_procedure('".$token."');");
        if (empty($DBresponse)) {
            return $this->sendError($body, "Nincs még rendelés az áruházban");
        } else {
            if ($DBresponse[0]->result == 0) {
                return $this->sendError($body, "Hibás token ilyen admin nem létezik");
            } else {
            return $this->sendResponse($DBresponse, "Felhasznalok rendelései sikeresen kilistázva");
            } 
        }     
    }

    public function getAllRendeltTermek(Request $req){
        $token = $req->bearerToken();
        $body = json_decode($req->getContent());
        $this->bearerToken()->hasBearer($token);
        $DBresponse = DB::select("CALL get_rendelt_termekek_procedure('".$token."');");
        if (empty($DBresponse)) {
            return $this->sendError($body, "Nincs még rendelt termek");
        } else {
            if ($DBresponse[0]->result == 0) {
                return $this->sendError($body, "Hibás token ilyen felhasználo nem létezik");
            } else {
                return $this->sendResponse($DBresponse, "Rendelt termékek kilistázva");
            }
        }
        return $DBresponse;
    }

    public function getOneRendelesTermekek($id){
        $DBresponse = DB::select("CALL get_one_rendeles_termekek_procedure(".$id.");");
        return $this->sendResponse($DBresponse, "A rendelés termékei sikeresen kilistázva");
    }

    public function updateRendeltTermek($id, Request $req){
        $token = $req->bearerToken();
        $this->bearerToken()->hasBearer($token);
        $DBresponse = DB::select("CALL update_rendelt_termek('".$token."',".$id.");");
        if ($DBresponse[0]->result == 0) {
            return $this->sendError($body, "Hibás token ilyen admin nem létezik");
        } else {
        return $this->sendResponse($DBresponse, "A termék kézbesitési álapota sikeresen modositva");
        } 
    }
}
