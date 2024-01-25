<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class TermekContoller extends Controller
{
    public function getTermekek(){
        $termekek = DB::select("call get_termekek_procedure();");

        return $termekek;
    }
}
