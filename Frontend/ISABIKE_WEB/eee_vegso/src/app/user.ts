export interface RegistrationPayload {
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
  }
export interface VerifyPayload {
    code: string;
}
export interface LoginPayload {
  email: string;
  password: string;
}