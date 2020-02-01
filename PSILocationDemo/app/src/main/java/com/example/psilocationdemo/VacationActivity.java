package com.example.psilocationdemo;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import com.archit.calendardaterangepicker.customviews.DateRangeCalendarView;

import java.util.Calendar;

public class VacationActivity extends AppCompatActivity {

    private static final String TAG = VacationActivity.class.getSimpleName();
    private DateRangeCalendarView calendar;
    String userEmail;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_vacation);

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setTitle("PSI Vacation");

        //Get passing value
        Intent intent = getIntent();
        userEmail = intent.getStringExtra("EMAIL");

        calendar = findViewById(R.id.calendar);

        calendar.setCalendarListener(new DateRangeCalendarView.CalendarListener() {
            @Override
            public void onFirstDateSelected(@NonNull Calendar startDate) {
                Toast.makeText(VacationActivity.this, "Start Date: " + startDate.getTime().toString(), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onDateRangeSelected(@NonNull Calendar startDate, @NonNull Calendar endDate) {
                Toast.makeText(VacationActivity.this, "Start Date: " + startDate.getTime().toString() + " End date: " + endDate.getTime().toString(), Toast.LENGTH_SHORT).show();
            }

        });

        findViewById(R.id.btnReset).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                calendar.resetAllSelectedViews();
            }
        });

        final Calendar current = Calendar.getInstance();
        calendar.setCurrentMonth(current);
    }

    public void openLocationActivity(View view) {
        Intent intent = new Intent(this, LocationActivity.class);
        intent.putExtra("EMAIL", userEmail);
        startActivity(intent);
    }
}
