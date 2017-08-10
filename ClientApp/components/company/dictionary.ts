interface idict{
    key:number,
    name: string
}

export default class Dictionary{

    _arr:boolean[] = Array(20);
    dictionary: idict[];

    constructor(){
        this.dictionary = Array<idict>();
    }

    public Add(item:idict):void
    {

        this.dictionary.push(item);
        if(this.check(item))
            {
                this.dictionary.push(item);
                console.log("added item to list");
            }
        else{
            console.log("already has a item with that key");
        } 
    }

    public Contains(key:number):boolean
    {
        return this._arr[key];
    }

    public Get(key:number):string
    {
        let d:idict[] = this.dictionary.filter(x=> x.key === key);

        return d[0].name;
    }

    private check(c:idict):boolean
    {
        if(this._arr[c.key] === false){

            return true;
        }
        return false;
    }

}