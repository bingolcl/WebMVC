package com.example.psilocationdemo;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class FormActivity extends AppCompatActivity {

    String address;
    String email;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_form);

        //Get passing value
        Intent intent = getIntent();
        email = intent.getStringExtra("EMAIL");
        address = intent.getStringExtra("ADDRESS");

        //Init View
        Toolbar toolbar=(Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setTitle("PSI Complete");

       // Toast.makeText(this, address, Toast.LENGTH_SHORT).show();

    }

    public void openCheckListActivity(View view){
        Intent intent = new Intent(FormActivity.this,CheckListActivity.class);
        intent.putExtra("ADDRESS", address);
        intent.putExtra("EMAIL", email);
        startActivity(intent);
    }

    public void openSumActivity(View view){
        Intent intent = new Intent(FormActivity.this,SumActivity.class);
        intent.putExtra("ADDRESS", address);
        intent.putExtra("EMAIL", email);
        startActivity(intent);
    }

}
