import { ThunkAction, UnknownAction, configureStore } from '@reduxjs/toolkit'
import categoryReducer from './categories/categories.slice'
import areaReducer from './areas/areas.slice'
import authReducer from './auth/auth.slice'
import userReducer from './user/user.slice'
import algoReducer from './algorithem/algo.slice'
import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux'
import algoAgendaIdReducer from './algorithem/algoAgendaId.slice'


export const store = configureStore({
    reducer: {
        auth: authReducer,
        category: categoryReducer,
        area: areaReducer,
        user: userReducer,
        algo: algoReducer,
        algoAgendaId: algoAgendaIdReducer
    }
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch

export const useAppDispatch: () => AppDispatch = useDispatch
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector

export type AppThunk<ReturnType = void> = ThunkAction<
    Promise<ReturnType> | ReturnType,
    RootState,
    unknown,
    UnknownAction
>