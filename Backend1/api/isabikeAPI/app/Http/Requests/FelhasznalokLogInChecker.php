<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class FelhasznalokLogInChecker extends FormRequest
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
            "email"=>"required|email",
            "password"=>"required|min:3|max:10"
        ];
    }

    public function messages(){
        return[
            "email.required"=>"Email megadása kötelezö",
            "password.required"=>"Jelszó megadása kötelezö",
            "email.email"=>"Email formátum nem helyes",
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
