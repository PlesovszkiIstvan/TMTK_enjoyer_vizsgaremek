<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class TermekKepAddChecker extends FormRequest
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
            'token' => 'required|string',
            'termek_id' => 'required|integer',
            'kep_helye' => 'required',
        ];
    }

    public function messages(){
        return[
            'token.required' => 'A token mező megadása kötelező.',
            'token.string' => 'A token mezőnek string típusúnak kell lennie.',
            'termek_id.required' => 'A termék azonosítója mező megadása kötelező.',
            'termek_id.integer' => 'A termék azonosítója mezőnek egész számnak kell lennie.',
            'kep_helye.required' => 'A kép helye mező megadása kötelező.',
            'kep_helye.string' => 'A kép helye mezőnek string típusúnak kell lennie.',
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
