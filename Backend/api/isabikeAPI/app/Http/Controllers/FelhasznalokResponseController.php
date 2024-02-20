<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;

class FelhasznalokResponseController extends Controller
{
    public function sendResponse($data, $message){
        $response=[
            "success"=> true,
            "data"=>$data,
            "message"=>$message
        ];
        return response()->json($response,201);
    }

    public function sendError($data, $message){
        $response=[
            "success"=> false,
            "data"=>$data,
            "message"=>$message
        ];
        return response()->json($response,405);
    }
}
