package com.example.psilocationdemo;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.core.app.ActivityCompat;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.google.android.gms.common.GooglePlayServicesNotAvailableException;
import com.google.android.gms.common.GooglePlayServicesRepairableException;
import com.google.android.gms.security.ProviderInstaller;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.security.NoSuchAlgorithmException;
import java.util.HashMap;
import java.util.Map;

import javax.net.ssl.SSLContext;


public class MainActivity extends AppCompatActivity {

    String userEmail;
    boolean success;
    EditText email;
    EditText password;
    TextView api_test;
    TextView ssl_test;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Init View
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        email = (EditText) findViewById(R.id.txt_email);
        password = (EditText) findViewById(R.id.txt_password);
        api_test = (TextView) findViewById(R.id.api_test);
        ssl_test = (TextView) findViewById(R.id.ssl_test);
        success = false;

        //initializeSSLContext(this);
        //getJsonArray(this);
        //userLogin(this);

    }
    public void verifyUser(View view) {
        if (!validateInput()) {
            email.setError("Email is required!");
        } else {
            userLogin(this);
        }
    }

    public void openLocationActivity() {
        if (!validateInput()) {
            email.setError("Email is required!");
        } else {
            userEmail = email.getText().toString().trim();
            Intent intent = new Intent(this, LocationActivity.class);
            intent.putExtra("EMAIL", userEmail);
            startActivity(intent);
        }
    }

    private boolean validateInput() {
        return (email.getText().toString().trim().equals("")) ? false : true;
    }

    private void apiTest() {
        RequestQueue requestQueue = Volley.newRequestQueue(this);
        final String url = "https://jsonplaceholder.typicode.com/todos/1";

        JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.GET, url, null, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                try {
                    StringBuilder formattedResult = new StringBuilder();
                    JSONArray responseJSONArray = response.getJSONArray("results");
                    for (int i = 0; i < responseJSONArray.length(); i++) {
                        formattedResult.append("\n" + responseJSONArray.getJSONObject(i).get("name") + "=> \t" + responseJSONArray.getJSONObject(i).get("rating"));
                    }
                    api_test.setText("List of Restaurants \n" + " Name" + "\t Rating \n" + formattedResult);
                } catch (JSONException e) {
                    e.printStackTrace();
                }
                //findViewById(R.id.progressBar).setVisibility(View.GONE);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                api_test.setText("An Error occured while making the request");
            }
        });
        requestQueue.add(jsonObjectRequest);
    }

    private void userLogin(Context context){
        findViewById(R.id.progressBar).setVisibility(View.VISIBLE);
        RequestQueue requestQueue = Volley.newRequestQueue(context);
        //final String url = "http://10.0.2.2:5000/api/Account/Login?email=czhang@escautomation.com&password=11312431Ci";
        String url = "http://192.168.50.20:8093/api/Account/Login?";
        userEmail = email.getText().toString().trim();
        String pass = password.getText().toString().trim();
        url += "email="+ userEmail+"&password="+ pass;
        JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.POST, url, null, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                try {
                    String message = response.getString("message");
                    success = response.getBoolean("success");
                    Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG).show();
                    if(success) openLocationActivity();
                } catch (JSONException e) {
                    e.printStackTrace();
                    Toast.makeText(getApplicationContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                }
                findViewById(R.id.progressBar).setVisibility(View.GONE);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Toast.makeText(getApplicationContext(), error.getMessage(), Toast.LENGTH_LONG).show();
            }
        });
        requestQueue.add(jsonObjectRequest);
    }

    private void getJsonObject(Context context) {
        RequestQueue requestQueue = Volley.newRequestQueue(context);
        final String url = "https://jsonplaceholder.typicode.com/todos/1";
        JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.GET, url, null, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                try {
                    String r = response.getString("title");
                    api_test.setText(r);
                } catch (JSONException e) {
                    e.printStackTrace();
                    api_test.setText(e.getMessage());
                }
                //findViewById(R.id.progressBar).setVisibility(View.GONE);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                api_test.setText(error.getMessage());
            }
        });
        requestQueue.add(jsonObjectRequest);
    }

    private void getJsonArray(Context context) {
        RequestQueue requestQueue = Volley.newRequestQueue(context);
        final String url = "http://10.0.2.2:5000/api/employee";
        final Context c = context;

        Toast.makeText(c, "getJsonArray", Toast.LENGTH_SHORT).show();

        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(Request.Method.GET, url, null,
                new Response.Listener<JSONArray>() {
                    @Override
                    public void onResponse(JSONArray response) {
                        String r = "";
                        for (int i = 0; i < response.length(); i++) {
                            JSONObject object = null;
                            try {
                                object = response.getJSONObject(i);
                                String employeeId = object.getString("employeeId");
                                String position = object.getString("position");
                                r += "ID: " + employeeId + "\n"
                                        + "Position: " + position + "\n";
                                api_test.setText(r);

                            } catch (JSONException e) {
                                e.printStackTrace();
                                api_test.setText(e.getMessage());
                            }
                        }
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        api_test.setText(error.getMessage());
                    }
                });
        requestQueue.add(jsonArrayRequest);
    }

    private void postRequest(Context context){
        RequestQueue requestQueue = Volley.newRequestQueue(context);
        final String url = "http://10.0.2.2:5000/api/Account/Login";
        final Context c = context;
        JSONObject jsonBody = new JSONObject();
        try {
            jsonBody.put("email", "czhang@escautomation.com");
            jsonBody.put("password", "11312431Ci");
        } catch (JSONException e) {
            e.printStackTrace();
            Toast.makeText(c, e.getMessage(), Toast.LENGTH_SHORT).show();
        }

        Toast.makeText(c, "postRequest", Toast.LENGTH_SHORT).show();

        JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.POST, url, jsonBody, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                try {
                    String r = response.getString("title");
                    ssl_test.setText(response.toString());
                } catch (JSONException e) {
                    e.printStackTrace();
                    ssl_test.setText(e.getMessage());
                }
                Toast.makeText(c, "request on", Toast.LENGTH_SHORT).show();
                //findViewById(R.id.progressBar).setVisibility(View.GONE);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                ssl_test.setText(error.getMessage());
            }
        });
        requestQueue.add(jsonObjectRequest);
    }

    private void initializeSSLContext(Context mContext) {
        try {
            SSLContext.getInstance("TLSv1.2");
            ssl_test.setText("TLSv1.2");
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
            ssl_test.setText(e.getMessage());
        }
        try {
            ProviderInstaller.installIfNeeded(mContext.getApplicationContext());
        } catch (GooglePlayServicesRepairableException e) {
            e.printStackTrace();
            ssl_test.setText(e.getMessage());
        } catch (GooglePlayServicesNotAvailableException e) {
            e.printStackTrace();
            ssl_test.setText(e.getMessage());
        }
    }

    private void sendWorkPostRequest(Context context) {
        RequestQueue requestQueue = Volley.newRequestQueue(context);
        try {
            String URL = "http://10.0.2.2:5000/api/Account/Login";
            JSONObject jsonBody = new JSONObject();

            jsonBody.put("email", "czhang@escautomation.com");
            jsonBody.put("password", "11312431Ci");

            JsonObjectRequest jsonOblect = new JsonObjectRequest(Request.Method.POST, URL, jsonBody, new Response.Listener<JSONObject>() {
                @Override
                public void onResponse(JSONObject response) {

                    Toast.makeText(getApplicationContext(), "Response:  " + response.toString(), Toast.LENGTH_SHORT).show();
                }
            }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {

                    Toast.makeText(getApplicationContext(), error.getMessage(), Toast.LENGTH_LONG).show();

                }
            }) {
                @Override
                public Map<String, String> getHeaders() throws AuthFailureError {
                    final Map<String, String> headers = new HashMap<>();
                    //headers.put("Authorization", "Basic " + "c2FnYXJAa2FydHBheS5jb206cnMwM2UxQUp5RnQzNkQ5NDBxbjNmUDgzNVE3STAyNzI=");//put your token here
                    return headers;
                }
            };

            requestQueue.add(jsonOblect);

        } catch (JSONException e) {
            e.printStackTrace();
            Toast.makeText(getApplicationContext(), e.getMessage(), Toast.LENGTH_LONG).show();
        }
        Toast.makeText(getApplicationContext(), "done", Toast.LENGTH_LONG).show();
    }


}
