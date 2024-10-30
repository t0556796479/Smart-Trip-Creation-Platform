

export type TripObjectType = {
    tripId: number | undefined
    tripName: string,
    description: string,
    categoryId: number,
    areaId: number,
    propertiesList: number[] | undefined,
    lat: number,
    lng: number,
    location: string
}