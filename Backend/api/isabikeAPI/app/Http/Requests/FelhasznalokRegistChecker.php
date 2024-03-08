<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class FelhasznalokRegistChecker extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, \Illuminate\Contracts\Validation\ValidationRule|array<mixed>|string>
     */
    public function rules(): array
    {
        return [
            "felhasznalo_nev"=>"required|min:3|max:10",
            "kereszt_nev"=>"required|min:3|max:10",
            "vezetek_nev"=>"required|min:3|max:10",
            "email"=>"required|email",
            "password"=>"required|min:3|regex:/^(?=.*[a-z])(?=.*[A-Z]).+$/"
        ];
    }

    public function messages(){
        return[
            "felhasznalo_nev.required"=>"Felhasználo név megadása kötelezö",
            "kereszt_nev.required"=>"Kereszt név megadása kötelezö",
            "vezetek_nev.required"=>"Vezeték név megadása kötelezö",
            "email.required"=>"Email megadása kötelezö",
            "email.email"=>"Email formátum hibás",
            "password.required"=>"Jelszo megadása kötelezö",

            "felhasznalo_nev.min"=>"Felhasználo név formátum hibás",
            "kereszt_nev.min"=>"Kereszt név formátum hibás",
            "vezetek_nev.min"=>"Vezeték név formátum hibás",
            "password.min"=>"Jelszo tull rövid",
            "password.regex" => "A jelszónak kis- és nagybetűket is kell tartalmaznia.",

            "felhasznalo_nev.max"=>"Felhasználo név formátum hibás",
            "kereszt_nev.max"=>"Kereszt név formátum hibás",
            "vezetek_nev.max"=>"Vezeték név formátum hibás",
        ];
    }

    public function failedValidation(Validator $validator){
        throw new HttpResponseException(response()->json([
            "success"=>false,
            "message"=>"Adatbeviteli hiba",
            "data"=>$validator->errors()
        ], 405));
    }
}
