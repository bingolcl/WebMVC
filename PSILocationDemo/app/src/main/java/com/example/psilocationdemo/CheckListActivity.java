package com.example.psilocationdemo;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CheckedTextView;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.TextView;
import android.widget.Toast;

public class CheckListActivity extends AppCompatActivity {

    String address;
    String email;
    String list;
    LinearLayout ll;
    int ccount;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_check_list);

        //Get passing value
        Intent intent = getIntent();
        email = intent.getStringExtra("EMAIL");
        address = intent.getStringExtra("ADDRESS");

        //Init View
        Toolbar toolbar=(Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setTitle("PSI Check-List");
        ll = (LinearLayout)findViewById(R.id.ll_list);
        ccount = ll.getChildCount();
    }

    public static int getScreenWidth() {
        return Resources.getSystem().getDisplayMetrics().widthPixels;
    }

    public static int getScreenHeight() {
        return Resources.getSystem().getDisplayMetrics().heightPixels;
    }

    private String getList(){
        String l = "";
        View v;
        for(int i=0; i<ccount;i++){
            v = ll.getChildAt(i);
            if(v instanceof CheckBox ){
                if(((CheckBox) v).isChecked()){
                    l += ((CheckBox) v).getText().toString() + "\nYES\n";
                }else{
                    l += ((CheckBox) v).getText().toString() + "\nNO\n";
                }

            }
            if(v instanceof EditText){
                l += "\nNote: "+ ((EditText) v).getText().toString()+ '\n';
            }
        }
        return l;
    }

    public void clearList(View v){
        for(int i=0; i<ccount;i++){
            v = ll.getChildAt(i);
            if(v instanceof CheckBox ){
                ((CheckBox) v).setChecked(false);
            }
            if(v instanceof EditText){
                ((EditText) v).setText("");
            }
            if(v instanceof CheckedTextView){
                ((CheckedTextView) v).setVisibility(View.GONE);
            }
        }
    }

    public void openSumActivity(View view){
        Intent intent = new Intent(CheckListActivity.this,SumActivity.class);
        list = getList();
        intent.putExtra("ADDRESS", address);
        intent.putExtra("EMAIL", email);
        intent.putExtra("LIST", list);
        startActivity(intent);
    }

    public void onCheckboxClicked(View view){
        // Is the view now checked?
        boolean checked = ((CheckBox) view).isChecked();

        // Check which checkbox was clicked
        switch(view.getId()) {
            case R.id.checkBox9:
                if (checked){
                    showView(R.id.txt_lockout);
                }else{
                    hideView(R.id.txt_lockout);
                }
                break;
            case R.id.checkBox10:
                if (checked){
                    showView(R.id.txt_energized);
                }else{
                    hideView(R.id.txt_energized);
                }
                break;
            default: break;
        }
    }

    private void showView(Integer id){
        View v = findViewById(id);
        v.setVisibility(View.VISIBLE);
    }
    private  void hideView(Integer id){
        View v = findViewById(id);
        v.setVisibility(View.GONE);
    }

}
