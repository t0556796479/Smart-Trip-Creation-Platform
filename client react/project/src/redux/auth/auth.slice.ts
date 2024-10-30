import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { AuthStateType, InitialStateAuth } from "../../types/auth.type";
import { UserType } from "../../types/user.types";



const initialState: InitialStateAuth = {
    user: null,
    //האם יש הרשאת גישה
    isAuthanticated: false,
    //האם הוא מאותחל
    isInitialized: false
}

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setUser: (state: AuthStateType, action: PayloadAction<UserType>) => {
            state.user = action.payload;
            state.isAuthanticated = true
        },
        setInitialize: (state: AuthStateType) => {
            state.isInitialized = true
        },
        logOut: (state: AuthStateType) => {
            state.user=null;
            state.isAuthanticated=false;
            state.isInitialized=false;
            localStorage.clear();
        },

    }
})

export const { setUser, setInitialize,logOut } = authSlice.actions

export default authSlice.reducer