import { PropertyType } from '../types/properties.types'
import axios from '../utils/axios'

export const getProperties = async () => {
    const response = await axios.get('/Properties')
    const properties = await response.data
    return properties
}

export const getPropertyById = async (id:Number) => {
    const response = await axios.get(`/Properties/${id}`)
    const property = response.data
    return property
}

export const addProperty = async (property:Omit<PropertyType, 'propertyId'>) => {
    const response = await axios.post('/Properties', property)
    const newProperty = response.data
    return newProperty
}

export const updateProperty = async (property: PropertyType, id: number) => {
    const response = await axios.put(`/Properties/${id}`, property)
    const updatedProperty = response.data
    return updatedProperty
}

export const deleteProperty = async (id: number) => {
    const response = await axios.delete(`/Properties/${id}`)
    return response
}

