<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class FelhasznaloController extends Controller
{

    public function logIn(){
        return $this->genToken();
    }

    private function genToken(){
        $auth = new OAuthProvider();
        $token = $auth->generateToken(16);
        return $token;
    }
}
