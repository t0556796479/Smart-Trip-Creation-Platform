import { UserType } from "./user.types";

export type AuthUserTyoe = {
    user: UserType,
    token: string
}

export type LoginUserType = {
    email: string,
    password: string
}

export type AuthStateType = {
    user: UserType | null,
    isAuthanticated: boolean,
    isInitialized: boolean
}

export type InitialStateAuth = {
    user: UserType | null,
    isAuthanticated: boolean,
    isInitialized: boolean
}