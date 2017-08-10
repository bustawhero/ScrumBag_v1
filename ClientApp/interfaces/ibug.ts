
export interface Bug{
        id:number,
        name: string,
        bugStatus: string,
        createDate?: Date,
        dueDate?: Date,
        extDescr: string,
        projType: string,
        backlog?: boolean,
        backlogDate?: Date,
        createdby: number,
        assignedUser: number,
        extractid: number
}


export interface ProjTask{

        id:number,
        bugid:number,
        taskType: string,
        descr: string,
        assignedTo: number,
        createDate: Date,
        complete: boolean,
        completeDate?: Date,
        dueDate?: Date
}