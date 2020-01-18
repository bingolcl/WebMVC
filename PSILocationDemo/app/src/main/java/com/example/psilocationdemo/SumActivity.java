package com.example.psilocationdemo;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class SumActivity extends AppCompatActivity {

    String email;
    String address;
    String list;
    TextView txt_email;
    TextView txt_address;
    TextView txt_list;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sum);

        //Get passing value
        Intent intent = getIntent();
        email = intent.getStringExtra("EMAIL");
        address = intent.getStringExtra("ADDRESS");
        list = intent.getStringExtra("LIST");

        //Init View
        Toolbar toolbar=(Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setTitle("PSI Summary");
        txt_email = (TextView)findViewById(R.id.txt_email);
        txt_address = (TextView)findViewById(R.id.txt_address);
        txt_list = (TextView)findViewById(R.id.txt_list);

        txt_email.setText(email);
        txt_address.setText(address);
        txt_list.setText(list);
    }

    public void submitPSI(View view){
        Toast.makeText(this, "PSI Submitted!", Toast.LENGTH_SHORT).show();
    }
}
