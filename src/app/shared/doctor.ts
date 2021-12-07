export class Doctor {
    DoctorId: number;
    DoctorName: string;
    DoctorSpecializationId: number;
    DoctorQualification: string;
    DoctorAge: number;
    DoctorGender: string;
    DoctorDateofBirth: Date = new Date();
    DoctorContactNo: string;
    DoctorLocation: string;
    IsActive: boolean;
    UserId:number;
}