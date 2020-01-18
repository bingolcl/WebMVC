package com.example.psilocationdemo;
import java.io.Serializable;
import java.util.List;

@SuppressWarnings("serial") //With this annotation we are going to hide compiler warnings
public class PSI implements Serializable {

    public PSI(String id, String note, List<String>list) {
        this.id = id;
        this.note = note;
        this.checkList = list;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getNote() {
        return this.note;
    }

    public void setNote(String name) {
        this.note = name;
    }

    public List<String> getList() {
        return this.checkList;
    }

    public void setList(List<String> list) {
        this.checkList = list;
    }

    public void listAdd(String item){
        this.checkList.add(item);
    }

    public String getItem(int index){
        return this.checkList.get(index);
    }

    public void listRemove(int index){
       this.checkList.remove(index);
    }

    public void clearList(){
        this.checkList.clear();
    }

    public String printList(){
        String r="";
        for (String s : checkList) {
            r += s +  "/n";
        }
        return r;
    }

    private String id;
    private String note;
    private List<String> checkList;
}
