<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class VelemenyekAddChecker extends FormRequest
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
            'ertekeles_id' => 'required|integer',
            'velemeny' => 'required|string',
        ];
    }

    public function messages(){
        return[
            'token.required' => 'A token mező megadása kötelező.',
            'token.string' => 'A token mezőnek string típusúnak kell lennie.',
            'ertekeles_id.required' => 'Az értékelés azonosítója mező megadása kötelező.',
            'ertekeles_id.integer' => 'Az értékelés azonosítója mezőnek egész számnak kell lennie.',
            'velemeny.required' => 'A vélemény mező megadása kötelező.',
            'velemeny.string' => 'A vélemény mezőnek string típusúnak kell lennie.',
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
