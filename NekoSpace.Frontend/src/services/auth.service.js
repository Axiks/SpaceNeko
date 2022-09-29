import axios from 'axios';

const API_URL = 'https://localhost:44373/api/Account/';

class AuthService {
    login(user) {
        return axios
            .post(API_URL + 'SignIn', {
                username: user.username,
                password: user.password
            })
            .then(response => {
                if (response.data.accessToken) {
                    localStorage.setItem('user', JSON.stringify(response.data));
                }

                return response.data;
            });
    }

    logout() {
        localStorage.removeItem('user');
    }

    register(user) {
        return axios.post(API_URL + 'Registration', {
            username: user.username,
            email: user.email,
            password: user.password,
            confirmPassword: user.password
        });
    }
}

export default new AuthService();