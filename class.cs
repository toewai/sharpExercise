class toDos implements toDo {
  constructor(useId:number , id:number ,title:string,completed : boolean){
    this._userId = useId;
    this._id = id;
    this._title =title;
    this._completed = completed;
  }
  private _userId: number;
  public get userId(): number {
    return this._userId;
  }
  public set userId(v: number) {
    this._userId = v;
  }

  private _id: number;
  public get id(): number {
    return this._id;
  }
  public set id(v: number) {
    this._id = v;
  }

  private _title: string;
  public get title(): string {
    return this._title;
  }
  public set title(v: string) {
    this._title = v;
  }

  private _completed: boolean;
  public get completed(): boolean {
    return this._completed;
  }
  public set completed(v: boolean) {
    this._completed = v;
  }
}
