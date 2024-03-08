<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;


class AddRendelesChecker extends FormRequest
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
            'token' => 'required|min:6|max:255',
            'vasarlo_telefonszama' => 'required|regex:/^[0-9]{11}$/',
            'szalitasi_cime' => 'required',
            'szalito_id' => 'required|integer',
            'fizetes_opcio_id' => 'required|integer',
            'kedvezmeny_id' => 'required|integer',
        ];
    }
 
    public function messages(){
        return[
            'token.required' => 'A token mező kitöltése kötelező.',
            'token.min' => 'A tokennek legalább 6 karakter hosszúnak kell lennie.',
            'token.max' => 'A token legfeljebb 255 karakter hosszú lehet.',
            'vasarlo_telefonszama.required' => 'A vásárló telefonszáma mező kitöltése kötelező.',
            'vasarlo_telefonszama.regex' => 'A vásárló telefonszáma nem érvényes.',
            'szalitasi_cime.required' => 'A szállítási cím mező kitöltése kötelező.',
            'szalito_id.required' => 'A szállító kiválasztása kötelező.',
            'fizetes_opcio_id.required' => 'A fizetési opció kiválasztása kötelező.',
            'kedvezmeny_id.required' => 'A kedvezmény kiválasztása kötelező.',
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
