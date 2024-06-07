export interface Auth {
  email: string
  password: string
}

export interface SignUp {
  nome: string
  cognome: string
  password: string
  email: string
}

export interface LoginData {
  user: Auth,
  accessToken: string
}
