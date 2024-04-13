<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class ErtekelesekController extends Controller
{
    public function getErtekelesek(){
        return DB::select("call get_ertekelesek_procedure();");
    }
}
