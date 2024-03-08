<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Mail;
use App\Mail\Email;

class EmailController extends Controller
{
    public function sendMail($code, $email){
        $content = [
            "title" => "Visza Igazolo kod",
            "code" => $code
        ];

        Mail::to( $email )->send( new Email($content) );
    }
}
