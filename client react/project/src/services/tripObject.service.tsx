import { TripObjectType } from '../types/tripObject.types'
import axios from '../utils/axios'

export const getTripObjects = async () => {
    const response = await axios.get('/TripObject')
    const tripObjects = await response.data
    return tripObjects
}

export const getTripObjectById = async (id:Number) => {
    const response = await axios.get(`/TripObject/${id}`)
    const tripObject = response.data
    return tripObject
}

export const addTripObject = async (tripObject:Omit<TripObjectType, 'tripId'>) => {
    const response = await axios.post('/TripObject', tripObject)
    const newTripObject = response.data
    return newTripObject
}

export const updateTripObject = async (tripObject: TripObjectType, id: number) => {
    const response = await axios.put(`/TripObject/${id}`, tripObject)
    const updatedTripObject = response.data
    return updatedTripObject
}

export const deleteTripObject = async (id: number) => {
    const response = await axios.delete(`/TripObject/${id}`)
    return response
}

