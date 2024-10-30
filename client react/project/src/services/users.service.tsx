import { UserType } from '../types/user.types'
import axios from '../utils/axios'

export const getUsers = async () => {
    const response = await axios.get('/User')
    const users = await response.data
    return users
}

export const getUserById = async (id: Number) => {
    const response = await axios.get(`/User/${id}`)
    const user = response.data
    return user
}

export const addUser = async (user: Omit<UserType, 'userId'>) => {
    const response = await axios.post('/User', user)
    const newUser = response.data
    return newUser
}

export const updateUser = async (user: UserType, id: number) => {
    const response = await axios.put(`/User/${id}`, user)
    const updatedUser = response.data
    return updatedUser
}

export const deleteUser = async (id: number) => {
    const response = await axios.delete(`/User/${id}`)
    return response
}

export const login = async (userName: string, password: string) => {
    const response = await axios.post(`User/${userName}/${password}`)
    return {
        user:  response.data.user,
        token: response.data.token
    }
}
