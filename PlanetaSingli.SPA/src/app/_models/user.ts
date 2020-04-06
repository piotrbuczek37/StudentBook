import { Photo } from './photo';

export interface User {
    id: number;
    username: string;
    gender: string;
    age: number;
    zodiacSign: string;
    created: Date;
    lastActive: Date;
    city: string;
    country: string;
    growth: string;
    eyeColor: string;
    hairColor: string;
    martialStatus: string;
    education: string;
    profession: string;
    children: string;
    languages: string;
    motto: string;
    description: string;
    personality: string;
    lookingFor: string;
    interests: string;
    freeTime: string;
    sport: any;
    movies: string;
    music: string;
    iLike: string;
    idoNotLike: string;
    makesMeLaugh: string;
    itFeelsBestIn: string;
    friendsWouldDescribeMe: string;
    photos: Photo[];
    photoUrl: string;
}
