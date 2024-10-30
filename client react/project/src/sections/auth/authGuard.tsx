import { ReactNode } from "react"
import { useAppSelector } from "../../redux/store"
import { Navigate, useLocation } from "react-router-dom"
import { selectAuth } from "../../redux/auth/auth.selectors"
import { PATHS } from "../../routes/paths"

type Props = {
    children: ReactNode
}

export default function AuthGuard({ children }: Props) {
    const { isAuthanticated, isInitialized } = useAppSelector(selectAuth)
    const { pathname } = useLocation()

    if (!isInitialized) {
        return <h1>Loading...</h1>
    }

    if (!isAuthanticated) {
        return <Navigate to={PATHS.signIn} state={pathname} />
    }

    return <>{children}</>
}